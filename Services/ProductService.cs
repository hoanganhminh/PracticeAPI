//using AutoMapper;
//using PracticeAPI.Models;
//using PracticeAPI.Models.Data.RequestDTO;
//using PracticeAPI.Models.Data.ResponseDTO;
//using PracticeAPI.Repositories.Contracts;
//using PracticeAPI.Services.Contracts;

//namespace PracticeAPI.Services
//{
//    public class ProductService : IProductService
//    {
//        private readonly IProductRepository _productRepository;
//        private readonly IMapper _mapper;

//        public ProductService(IProductRepository productRepository, IMapper mapper)
//        {
//            _productRepository = productRepository;
//            _mapper = mapper;
//        }

//        public async Task<List<ProductResponseDTO>> GetAllProducts()
//        {
//            try
//            {
//                var products = _mapper.Map<List<ProductResponseDTO>>(await _productRepository.GetAllProducts());
//                return products;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public async Task<ProductResponseDTO> GetProductById(int id)
//        {
//            try
//            {
//                var product = _mapper.Map<ProductResponseDTO>(await _productRepository.GetProductById(id));
//                return product;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public async Task<ProductRequestDTO> CreateProduct(ProductRequestDTO productRequestDTO)
//        {
//            try
//            {
//                _productRepository.AddProduct(productRequestDTO);
//                await _productRepository.SaveAsync();
//                return productRequestDTO;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public async Task<bool> UpdateProduct(ProductRequestDTO productRequestDTO)
//        {
//            try
//            {
//                _productRepository.UpdateProduct(productRequestDTO);
//                await _productRepository.SaveAsync();

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public async Task<bool> DeleteProduct(int id)
//        {
//            try
//            {
//                var product = await _productRepository.GetProductById(id);
//                if (product == null)
//                {
//                    return false;
//                }

//                _productRepository.DeleteProduct(product);
//                await _productRepository.SaveAsync();

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//    }
//}
