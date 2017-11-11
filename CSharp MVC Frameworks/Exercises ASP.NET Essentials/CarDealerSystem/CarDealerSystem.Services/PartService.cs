using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Parts;
using CarDealerSystem.Services.Models.Suppliers;
using CarDealerSystem.Web.Data;
using System.Linq;

namespace CarDealerSystem.Services
{
    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void AddPart(AddPartModel model)
        {
            this.db.Parts.Add(new Part()
            {
                Name = model.Name,
                Price = model.Price.Value,
                Quantity = model.Quantity.Value,
                SupplierId = model.SupplierId.Value
            });

            this.db.SaveChanges();
        }

        public void DeletePart(int id)
        {
            if (this.db.Parts.Any(p => p.Id == id))
            {
                var part = this.db.Parts.First(p => p.Id == id);

                this.db.Parts.Remove(part);

                this.db.SaveChanges();
            }
        }

        public AllPartsModel GetAllParts()
        {
            var model = new AllPartsModel()
            {
                Parts = this.db.Parts.Select(p => new PartListingModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
            };

            return model;
        }

        public EditDeletePartModel GetPartInfo(int id)
        {
            if (!this.db.Parts.Any(p => p.Id == id))
            {
                return null;
            }

            var model = this.db.Parts.Where(p => p.Id == id)
                .Select(p => new EditDeletePartModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).First();

            return model;
        }

        public AddPartModel GetPartModelWithSuppliers()
        {
            AddPartModel model = new AddPartModel()
            {
                Suppliers = this.db.Suppliers.Select(s => new SupplierSelectModel() { Id = s.Id, Name = s.Name })
            };

            return model;
        }

        public void UpdatePart(EditDeletePartModel model)
        {
            var part = this.db.Parts.First(p => p.Id == model.Id.Value);

            part.Price = model.Price.Value;
            part.Quantity = model.Quantity.Value;

            this.db.SaveChanges();
        }
    }
}