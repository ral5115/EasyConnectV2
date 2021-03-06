using EasyConnect.Infrastructure.Entities;
using EasyConnect.Infrastructure.Mappings;
using EasyConnect.Infrastructure.Repositories;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Mappings;
using EasyTools.Infrastructure.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EasyTools.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private ITransaction transaction;

        public UnitOfWork(DatabaseSetting confg)
            : base(confg)
        {
        }


        public override void AddDefaultConfig(DatabaseSetting confg)
        {
            confg.Types.Add(typeof(CONEquivalenceDetailMap));
            confg.Types.Add(typeof(CONEquivalenceMap));
            confg.Types.Add(typeof(CONErrorMap));
            confg.Types.Add(typeof(CONIntegratorConfigurationMap));
            confg.Types.Add(typeof(CONIntegratorMap));
            confg.Types.Add(typeof(CONRecordDetailMap));
            confg.Types.Add(typeof(CONRecordMap));
            confg.Types.Add(typeof(CONSQLDetailMap));
            confg.Types.Add(typeof(CONSQLParameterMap));
            confg.Types.Add(typeof(CONSQLMap));
            confg.Types.Add(typeof(CONSQLSendMap));
            confg.Types.Add(typeof(CONStructureAssociationMap));
            confg.Types.Add(typeof(CONStructureDetailMap));
            confg.Types.Add(typeof(CONStructureMap));
            confg.Types.Add(typeof(SECCompanyMap));
            confg.Types.Add(typeof(SECConnectionMap));
            confg.Types.Add(typeof(SECRolePermissionMap));
            confg.Types.Add(typeof(SECRoleMap));
            confg.Types.Add(typeof(SECUserCompanyMap));
            confg.Types.Add(typeof(SECUserMap));
            confg.Types.Add(typeof(EXTFileOperaMap));
            confg.Types.Add(typeof(EXTFileOperaDetailMap));
            confg.Types.Add(typeof(CONWSEquivalenciasFormasPagoMap));
            confg.Types.Add(typeof(WSCONCESIONEMap));
            confg.Types.Add(typeof(WSCONCESIONESTIENDAMap));
            PersistenceManager.SetConfigure(confg);
        }

        public override void LoadReposiories()
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, dynamic>();
            _repositories.Add(typeof(CONEquivalenceDetail).Name, new CONEquivalenceDetailRepository(this));
            _repositories.Add(typeof(CONEquivalence).Name, new CONEquivalenceRepository(this));
            _repositories.Add(typeof(CONError).Name, new CONErrorRepository(this));
            _repositories.Add(typeof(CONIntegratorConfiguration).Name, new CONIntegratorConfigurationRepository(this));
            _repositories.Add(typeof(CONIntegrator).Name, new CONIntegratorRepository(this));
            _repositories.Add(typeof(CONRecordDetail).Name, new CONRecordDetailRepository(this));
            _repositories.Add(typeof(CONRecord).Name, new CONRecordRepository(this));
            _repositories.Add(typeof(CONSQLDetail).Name, new CONSQLDetailRepository(this));
            _repositories.Add(typeof(CONSQLParameter).Name, new CONSQLParameterRepository(this));
            _repositories.Add(typeof(CONSQL).Name, new CONSQLRepository(this));
            _repositories.Add(typeof(CONSQLSend).Name, new CONSQLSendRepository(this));
            _repositories.Add(typeof(CONStructureAssociation).Name, new CONStructureAssociationRepository(this));
            _repositories.Add(typeof(CONStructureDetail).Name, new CONStructureDetailRepository(this));
            _repositories.Add(typeof(CONStructure).Name, new CONStructureRepository(this));
            _repositories.Add(typeof(SECCompany).Name, new SECCompanyRepository(this));
            _repositories.Add(typeof(SECConnection).Name, new SECConnectionRepository(this));
            _repositories.Add(typeof(SECRolePermission).Name, new SECRolePermissionRepository(this));
            _repositories.Add(typeof(SECRole).Name, new SECRoleRepository(this));
            _repositories.Add(typeof(SECUserCompany).Name, new SECUserCompanyRepository(this));
            _repositories.Add(typeof(SECUser).Name, new SECUserRepository(this));
            _repositories.Add(typeof(EXTFileOpera).Name, new EXTFileOperaRepository(this));
            _repositories.Add(typeof(EXTFileOperaDetail).Name, new EXTFileOperaDetailRepository(this));
            _repositories.Add(typeof(CONWSEquivalenciasFormasPago).Name, new CONWSEquivalenciasFormasPagoRepository(this));
            _repositories.Add(typeof(WSCONCESIONE).Name, new WSCONCESIONERepository(this));
            _repositories.Add(typeof(WSCONCESIONESTIENDA).Name, new WSCONCESIONESTIENDARepository(this));


        }

        
    }
}