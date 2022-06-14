﻿using Atacado.Dal.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Poco.Estoque;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class CategoriaService : BaseAncestralService<CategoriaPoco>
    {
        private CategoriaMapper mapConfig;
        private CategoriaDao dao;

        public CategoriaService()
        {
            this.mapConfig = new CategoriaMapper();
            this.dao = new CategoriaDao();
        }

        public override List<CategoriaPoco> Listar()
        {
            List<Categoria> listDOM = this.dao.ReadAll();
            List<CategoriaPoco> listPOCO = new List<CategoriaPoco>();
            foreach (Categoria item in listDOM)
            {
                CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(item);
                listPOCO.Add(poco);
            }
            return listPOCO;
        }

        public override CategoriaPoco Selecionar(int id)
        {
            Categoria dom = this.dao.Read(id);
            CategoriaPoco poco = this.mapConfig.Mapper.Map<CategoriaPoco>(dom);
            return poco;
        }

    }
}
