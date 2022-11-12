using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using static challenge.Services.ImageService;

namespace AlkemyWallet.Core.Services;

public class CatalogueService : ICatalogueService
{
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CatalogueService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<Catalogue?> GetCatalogueById(int id)
    {
        var catalogue = await _unitOfWork.CatalogueRepository!.GetById(id);
        return catalogue;
    }

    public async Task<IEnumerable<Catalogue>> GetCatalogueByPoints(int userId)
    {
        var userEntity = await _unitOfWork.UserRepository!.GetById(userId);
        var catalogues = await _unitOfWork.CatalogueByPoints!.GetByPoints(userEntity!.Points);

        return catalogues;
    }

    public async Task<IEnumerable<Catalogue>> GetCatalogues()
    {
        var catalogues = await _unitOfWork.CatalogueRepository!.GetAll();
        catalogues = catalogues.OrderBy(x => x.Points);
        return catalogues;
    }

    public async Task InsertCatalogue(CatalogueForCreationDTO catalogueDTO)
    {
        var path = "";

        if (catalogueDTO.ImageFile is not null)
            path = await _imageService.StoreImage(catalogueDTO.ImageFile, ImageType.Catalogue);

        var catalogue = _mapper.Map<Catalogue>(catalogueDTO);
        catalogue.Image = path;

        await _unitOfWork.CatalogueRepository!.Insert(catalogue);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteCatalogue(int id)
    {
        await _unitOfWork.CatalogueRepository!.Delete(id);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateCatalogues(int id, CatalogueForUpdateDTO catalogueDTO)
    {
        var catalogueEntity = await _unitOfWork.CatalogueRepository!.GetById(id);

        if (catalogueEntity is null)
            return false;

        if (catalogueDTO.Points is not null) catalogueEntity.Points = catalogueDTO.Points.Value;

        if (catalogueDTO.ImageFile is not null)
        {
            var path = await _imageService.StoreImage(catalogueDTO.ImageFile, ImageType.Catalogue);

            catalogueEntity.Image = path;
        }

        if (catalogueDTO.Product_description is not null)
            catalogueEntity.Product_description = catalogueDTO.Product_description;


        await _unitOfWork.CatalogueRepository.Update(catalogueEntity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<(int totalPages, IEnumerable<Catalogue> recordList)> GetCataloguesPaging(int pageNumber,
        int pageSize)
    {
        return await _unitOfWork.CatalogueByPoints!.GetCataloguesPaging(pageNumber, pageSize);
    }
}