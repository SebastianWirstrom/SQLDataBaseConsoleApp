﻿using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class AddressService(AddressRepository addressRepository)
    {
        private readonly AddressRepository _addressRepository = addressRepository;

        public AddressEntity CreateAddress(string streetName, string postalCode, string city)
        {
            var addressEntity = _addressRepository.GetSingle(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (addressEntity == null)
            {
                addressEntity = _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });
                return addressEntity;
            }
            else
            {
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
