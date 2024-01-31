using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services
{
    public class AddressService(AddressRepository addressRepository)
    {
        private readonly AddressRepository _addressRepository = addressRepository;

        public AddressEntity CreateAddress(AddressDTO address)
        {
            try
            {
                var addressEntity = _addressRepository.GetSingle(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode && x.City == address.City);
                if (addressEntity == null)
                {
                    addressEntity = _addressRepository.Create(new AddressEntity
                    {
                        StreetName = address.StreetName,
                        PostalCode = address.PostalCode,
                        City = address.City
                    });
                }
                return addressEntity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in CreateAddress: {ex}");
                
                Debug.WriteLine(ex.StackTrace);
                return null!;
            }
        }

        public AddressEntity GetAddress(string streetName, string postalCode, string city)
        {
            var addressEntity = _addressRepository.GetSingle(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return addressEntity;
        }

        public AddressEntity GetAddressById(int id)
        {
            var addressEntity = _addressRepository.GetSingle(x => x.Id == id);
            return addressEntity;
        }

        public IEnumerable<AddressEntity> GetAddresses()
        {
            var addresses = _addressRepository.GetAll();
            return addresses;
        }

        public AddressEntity UpdateAddress(AddressEntity addressEntity)
        {
            var updatedAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
            return updatedAddressEntity;
        }

        public bool DeleteAddress(int id)
        {
            _addressRepository.Delete(x => x.Id == id);
            return true;
        }
    }
}
