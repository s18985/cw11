using cw11.DTOs.Requests;
using cw11.DTOs.Responses;
using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.DAL
{
    public interface IDoctorDbService
    {
        List<Doctor> GetDoctors();

        AddDoctorResponse AddDoctor(AddDoctorRequest request);

        ModifyDoctorResponse ModifyDoctor(int id, ModifyDoctorRequest request);

        bool DeleteDoctor(int id);
    }
}
