using ClinicSystem.Context;
using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class GenderRep : IGenderRep
    {
        private readonly DbContainer db;

        public GenderRep(DbContainer db)
        {
            this.db = db;
        }

        public bool AddGender(Gender obj)
        {
            db.gender.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool DeleteGender(int id)
        {
            Gender obj = db.gender.Find(id);
            obj.IsDeleted = true;
            db.SaveChanges();
            return true;
        }

        public bool EditGender(Gender obj)
        {
            Gender old = db.gender.Find(obj.Id);
            old.GenderName = obj.GenderName;
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Gender> GetAllGenders()
        {
            return db.gender.Where(a => a.IsDeleted == false);
        }

        public Gender GetGenderById(int id)
        {
            return db.gender.Find(id);
        }
    }
}
