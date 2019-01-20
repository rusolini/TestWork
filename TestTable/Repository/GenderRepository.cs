using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dropdownlistmvc.Data;

namespace Dropdownlistmvc.Repository
{
    public class GenderRepository : IGender
    {
        readonly EFDbContext _context = new EFDbContext();

        public void Delete(int? Id)
        {
            Gender gd = _context.Genders.Find(Id);
            if (gd != null)
            {
                _context.Genders.Remove(gd);
                _context.SaveChanges();
            }

        }

        public Gender GetGender(int? Id)
        {
            return _context.Genders.Find(Id);
        }

        public void Save(Gender gender)
        {
            if (gender.GenderId == 0)
            {
                _context.Genders.Add(gender);
                _context.SaveChanges();
            }
            else
            {
                Gender dbEntry = _context.Genders.Find(gender.GenderId);
                dbEntry.GenderId = gender.GenderId;
                dbEntry.GenderName = gender.GenderName;
            }
        }

        public IEnumerable<Gender> GetGenders => _context.Genders;
    }
}