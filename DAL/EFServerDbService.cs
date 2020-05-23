using cw11.DTOs.Requests;
using cw11.DTOs.Responses;
using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.DAL
{
    public class EFServerDbService : IDoctorDbService
    {
        public AddDoctorResponse AddDoctor(AddDoctorRequest request)
        {
            var db = new CodeFirstContext();

            var d = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            db.Doctor.Add(d);
            db.SaveChanges();

            var res = new AddDoctorResponse
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            };

            return res;
        }

        public bool DeleteDoctor(int id)
        {
            var db = new CodeFirstContext();

            var d = db.Doctor.Where(x => x.IdDoctor == id).FirstOrDefault();

            if (d == null)
            {
                return false;
            }
            else
            {
                db.Remove(d);
                db.SaveChanges();
                return true;
            }
        }

        public List<Doctor> GetDoctors()
        {
            var db = new CodeFirstContext();

            var res = db.Doctor.ToList();

            return res;
        }

        public ModifyDoctorResponse ModifyDoctor(int id, ModifyDoctorRequest request)
        {
            var db = new CodeFirstContext();

            var d = db.Doctor.Where(x => x.IdDoctor == id).FirstOrDefault();

            if (d == null)
            {
                return null;
            }
            else
            {

                d.FirstName = request.FirstName;
                d.LastName = request.LastName;
                d.Email = request.Email;
                db.SaveChanges();

                ModifyDoctorResponse response = new ModifyDoctorResponse
                {
                    IdDoctor = d.IdDoctor,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Email = d.Email
                };

                return response;
            }
        }
    }
}