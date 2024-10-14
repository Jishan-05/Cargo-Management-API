using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Services
{
    public class PricingService
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingService(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<List<PricingDto>> GetAllPricingAsync()
        {
            var pricingList = await _pricingRepository.GetAllPricingAsync();

            return pricingList.ConvertAll(p => new PricingDto
            {
                BasePrice = p.BasePrice,
                PricePerKm = p.PricePerKm,
                PricePerKg = p.PricePerKg
            });
        }

        public async Task<PricingDto> GetPricingByIdAsync(int id)
        {
            var pricing = await _pricingRepository.GetPricingByIdAsync(id);
            if (pricing == null) throw new KeyNotFoundException("Pricing record not found.");

            return new PricingDto
            {
                BasePrice = pricing.BasePrice,
                PricePerKm = pricing.PricePerKm,
                PricePerKg = pricing.PricePerKg
            };
        }

        public async Task CreatePricingAsync(CreatePricingDto createPricingDto)
        {
            var pricing = new Pricing
            {
                BasePrice = createPricingDto.BasePrice,
                PricePerKm = createPricingDto.PricePerKm,
                PricePerKg = createPricingDto.PricePerKg,
                CreatedAt = DateTime.Now
            };

            await _pricingRepository.CreatePricingAsync(pricing);
        }

        public async Task UpdatePricingAsync(int id, UpdatePricingDto updatePricingDto)
        {
            var pricing = await _pricingRepository.GetPricingByIdAsync(id);
            if (pricing == null) throw new KeyNotFoundException("Pricing record not found.");

            pricing.BasePrice = updatePricingDto.BasePrice;
            pricing.PricePerKm = updatePricingDto.PricePerKm;
            pricing.PricePerKg = updatePricingDto.PricePerKg;
            pricing.UpdatedAt = DateTime.Now;

            await _pricingRepository.UpdatePricingAsync(pricing);
        }

        public async Task DeletePricingAsync(int id)
        {
            await _pricingRepository.DeletePricingAsync(id);
        }
    }
}
