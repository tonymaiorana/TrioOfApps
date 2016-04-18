using CarDealership.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> Cars = new List<Vehicle>();

        private string constr;

        public VehicleRepository()
        {
            constr = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
        }

        public List<Vehicle> GetAll()
        {
            //[VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]
            using (var _cn = new SqlConnection(constr))
            {
                List<Vehicle> Cars = new List<Vehicle>();
                Cars = _cn.Query<Vehicle>("SELECT * FROM Vehicle ").ToList();
                return Cars;
            }
        }

        public Vehicle GetById(int id)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                var car = _cn.Query<Vehicle>("SELECT * " +
                                                  "FROM Vehicle " +
                                                  "WHERE VehicleID = @ID ", parameters).FirstOrDefault();
                return car;
            }
        }

        public Vehicle AddVehicle(Vehicle model)
        {
            Cars = GetAll();
            Cars.Add(model);

            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                //[VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]

                parameters.Add("Make", model.Make);
                parameters.Add("Model", model.Model);
                parameters.Add("Year", model.Year);
                parameters.Add("Mileage", model.Mileage);
                parameters.Add("AdTitle", model.AdTitle);
                parameters.Add("Description", model.Description);
                parameters.Add("Price", model.Price);
                parameters.Add("PictureUrl", model.PictureUrl);
                parameters.Add("IsAvailable", model.IsAvailable);
                parameters.Add("IsNew", model.IsNew);

                string query = "INSERT INTO Vehicle (Make, Model, [Year], Mileage, AdTitle, [Description], Price, PictureUrl, IsAvailable, IsNew) " +
                    " VALUES (@Make, @Model, @Year, @Mileage, @AdTitle, @Description, @Price, @PictureUrl, @IsAvailable, @IsNew) ";
                _cn.Execute(query, parameters);
            }

            return model;
        }

        public void Update(int id, Vehicle model)
        {
            var carToEdit = GetById(id);
            carToEdit = model;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                //[VehicleId], [Make], [Model], [Year], [Mileage], [AdTitle], [Description], [Price], [PictureUrl], [IsAvailable], [IsNew]
                parameters.Add("id", id);
                parameters.Add("Make", carToEdit.Make);
                parameters.Add("Model", carToEdit.Model);
                parameters.Add("Year", carToEdit.Year);
                parameters.Add("Mileage", carToEdit.Mileage);
                parameters.Add("AdTitle", carToEdit.AdTitle);
                parameters.Add("Description", carToEdit.Description);
                parameters.Add("Price", carToEdit.Price);
                parameters.Add("PictureUrl", carToEdit.PictureUrl);
                parameters.Add("IsAvailable", carToEdit.IsAvailable);
                parameters.Add("IsNew", carToEdit.IsNew);

                string query = "UPDATE Vehicle SET Make=@Make, Model=@Model, [Year]=@Year, Mileage=@Mileage, AdTitle=@AdTitle, [Description]=@Description, " +
                    "Price=@Price, PictureUrl=@PictureUrl, IsAvailable=@IsAvailable, IsNew=@IsNew WHERE VehicleId=@ID";
                _cn.Execute(query, parameters);
            }
        }

        public void Delete(int id)
        {
            var CarToDelete = GetById(id);
            CarToDelete.IsAvailable = false;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IsActive", CarToDelete.IsAvailable);
                parameters.Add("ID", id);
                string query = "UPDATE Vehicle SET IsAvailable = @IsAvailable " +
                                                "WHERE VehicleId = @id ";
                _cn.Execute(query, parameters);
            }
        }
    }
}