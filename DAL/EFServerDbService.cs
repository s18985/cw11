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
        private CodeFirstContext _context;

        public EFServerDbService(CodeFirstContext context)
        {
            _context = context;
        } 


        public AddDoctorResponse AddDoctor(AddDoctorRequest request)
        {
            var d = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            _context.Doctor.Add(d);
            _context.SaveChanges();

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
            var d = _context.Doctor.Where(x => x.IdDoctor == id).FirstOrDefault();

            if (d == null)
            {
                return false;
            }
            else
            {
                _context.Remove(d);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Doctor> GetDoctors()
        {
            var res = _context.Doctor.ToList();

            return res;
        }

        public ModifyDoctorResponse ModifyDoctor(int id, ModifyDoctorRequest request)
        {
            var d = _context.Doctor.Where(x => x.IdDoctor == id).FirstOrDefault();

            if (d == null)
            {
                return null;
            }
            else
            {

                d.FirstName = request.FirstName;
                d.LastName = request.LastName;
                d.Email = request.Email;
                _context.SaveChanges();

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