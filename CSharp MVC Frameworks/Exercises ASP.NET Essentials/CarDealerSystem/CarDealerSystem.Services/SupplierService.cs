using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Suppliers;
using CarDealerSystem.Web.Data;
using System.Linq;

namespace CarDealerSystem.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void AddSupplier(AddSupplierModel addSupplierModel)
        {
            this.db.Suppliers.Add(new Supplier()
            {
                Name = addSupplierModel.Name,
                IsImporter = addSupplierModel.Importer
            });

            this.db.SaveChanges();
        }

        public AllSuppliersModel All()
        {
            var model = new AllSuppliersModel()
            {
                Suppliers = this.db.Suppliers.Select(s => new SupplierListModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Importer = s.IsImporter
                }).ToList()
            };

            return model;
        }

        public AllFilteredSuppliersModel AllFiltered(string region)
        {
            var query = this.db.Suppliers.AsQueryable();

            if (region == "local")
            {
                query = query.Where(s => !s.IsImporter).AsQueryable();
            }
            else
            {
                query = query.Where(s => s.IsImporter).AsQueryable();
            }

            var result = new AllFilteredSuppliersModel()
            {
                Suppliers = query.Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                }).ToList()
            };

            return result;
        }

        public void DeleteById(int id)
        {
            if (this.db.Suppliers.Any(s => s.Id == id))
            {
                var supplier = this.db.Suppliers.First(s => s.Id == id);

                this.db.Remove(supplier);
                this.db.SaveChanges();
            }
        }

        public void EditSupplier(SupplierModifyModel supplierModifyModel)
        {
            if (this.db.Suppliers.Any(s => s.Id == supplierModifyModel.Id))
            {
                var supplier = this.db.Suppliers.First(s => s.Id == supplierModifyModel.Id);

                supplier.Name = supplierModifyModel.Name;
                supplier.IsImporter = supplierModifyModel.Importer;

                this.db.SaveChanges();
            }
        }

        public SupplierModifyModel GetEditModelById(int id)
        {
            var model = this.db.Suppliers.Where(s => s.Id == id)
                .Select(s => new SupplierModifyModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Importer = s.IsImporter
                }).FirstOrDefault();

            return model;
        }
    }
}