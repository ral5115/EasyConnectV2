using EasyTools.Framework.Application;
using EasyTools.Framework.Persistance;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace EasyTools.Framework.Data
{
    public abstract class IDomainLogic<T> where T : FrameworkEntity
    {
        public bool CommitTransaction { get; set; }

        public IUnitOfWork Work { get; protected set; }

        private List<string> exceptionMessages;

        public List<string> ExceptionMessages
        {
            get
            {
                if (exceptionMessages == null)
                    exceptionMessages = new List<string>();
                return exceptionMessages;
            }
            set
            {
                exceptionMessages = value;
            }
        }

        public FaultException<BusinessException> GetBusinessException()
        {
            BusinessException exception = new BusinessException("Validaciones de Negocio");
            foreach (string item in ExceptionMessages)
            {
                exception.AppMessageDetails.Add(item);
            }
            return exception.GetFaultException();
        }

        public virtual T Execute(T data, Actions action, Options option, string token)
        {
            if (action == Actions.Add)
                return Add(data);
            else if (action == Actions.Modify)
                return Modify(data);
            else if (action == Actions.Remove)
                return Remove(data);
            else if (action == Actions.Find && option == Options.Me)
                return FindById(data);
            else
            {
                data.Exist = Exist(data);
                return data;
            }
        }

        public virtual T Add(T data)
        {
            try
            {
                Work.BeginTransaction();
                CommonRules(data);
                AddRules(data);
                if (!HasErrors)
                {
                    data = Work.Repository<T>().Add(data);
                    return data;
                }
                else
                    throw GetBusinessException();
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public async Task<T> AddAsync(T data)
        {
            return await Task.Run(() =>
            {
                return Add(data);
            });
        }

        public virtual T Modify(T data)
        {
            try
            {
                Work.BeginTransaction();
                CommonRules(data);
                ModifyRules(data);
                if (!HasErrors)
                {
                    data = Work.Repository<T>().Modify(data);
                    return data;
                }
                else
                    throw GetBusinessException();
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public async Task<T> ModifyAsync(T data)
        {
            return await Task.Run(() =>
            {
                return Modify(data);
            });
        }

        public virtual T Remove(T data)
        {
            try
            {
                Work.BeginTransaction();
                RemoveRules(data);
                if (!HasErrors)
                {
                    data = Work.Repository<T>().Remove(data);
                    return data;
                }
                else
                    throw GetBusinessException();
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public virtual T Remove(List<T> datas)
        {
            try
            {
                List<T> removes = new List<T>();
                Work.BeginTransaction();
                if (datas != null && datas.Count > 0)
                    for (int i = 0; i < datas.Count; i++)
                    {
                        RemoveRules(datas[i]);
                    }
                if (!HasErrors)
                {
                    T data = Work.Repository<T>().Remove(datas);
                    return data;
                }
                else
                    throw GetBusinessException();
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public async Task<T> RemoveAsync(T data)
        {
            return await Task.Run(() =>
            {
                return Modify(data);
            });
        }

        public virtual bool Exist(T data)
        {
            FindByIdRules(data);
            if (!HasErrors)
                return Work.Repository<T>().Exist(data);
            else
            {
                throw GetBusinessException();
            }
        }

        public async Task<bool> ExistAsync(T data)
        {
            return await Task.Run(() =>
            {
                return FindById(data) != null;
            });
        }

        public virtual T FindById(T data)
        {
            try
            {
                FindByIdRules(data);
                if (!HasErrors)
                    return Work.Repository<T>().FindById(data);
                else
                    throw GetBusinessException();
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public async Task<T> FindByIdAsync(T data)
        {
            return await Task.Run(() =>
            {
                return FindById(data);
            });
        }

        public virtual List<T> FindAll(T data, Options option)
        {
            try
            {
                return Work.Repository<T>().FindAll(data, option);
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public async Task<List<T>> FindAllAsync(T data, Options option)
        {
            return await Task.Run(() =>
            {
                return FindAll(data, option);
            });
        }


        public virtual int GetConsecutive(string idSedcuence)
        {
            return Work.Repository<T>().GetConsecutive(idSedcuence);
        }

        public virtual void CommonRules(T data) { }

        public virtual void AddRules(T data) { }

        public virtual void ModifyRules(T data) { }

        public virtual void RemoveRules(T data) { }

        public virtual void FindByIdRules(T data) { }

        public bool HasErrors
        {
            get
            {
                return ExceptionMessages.Count > 0;
            }
        }

        public void AddExceptionMessage(string message, params string[] args)
        {
            ExceptionMessages.Add(String.Format(message, args));
        }

        public string GetLocalizedMessage(string message, params string[] args)
        {
            return string.Format(message, args);
        }

        public void Commit()
        {
            if (CommitTransaction)
            {
                Work.Commit();
                if (Work.Session != null && Work.Session.IsOpen)
                    Work.Session.Close();
            }
        }

        public void Rollback()
        {
            if (CommitTransaction)
            {
                Work.Rollback();
            }
        }

        public void BenginTransaction()
        {
            this.Work.BeginTransaction();
        }
    }

}