using CarDealerSystem.Services.Models.Parts;

namespace CarDealerSystem.Services.Contracts
{
    public interface IPartService
    {
        AddPartModel GetPartModelWithSuppliers();

        void AddPart(AddPartModel model);

        AllPartsModel GetAllParts();

        EditDeletePartModel GetPartInfo(int id);

        void UpdatePart(EditDeletePartModel model);

        void DeletePart(int id);
    }
}