using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services
{
    public class CustomerService(CustomerRepository customerRepository, RoleRepository roleRepository, AddressRepository addressRepository)
    {
        private readonly CustomerRepository _customerRepository = customerRepository;
        private readonly AddressRepository _addressRepository = addressRepository;
        private readonly RoleRepository _roleRepository = roleRepository;

        public CustomerEntity CreateCustomer(CustomerDTO customer) 
        {
            try
            {
                var roleEntity = new RoleEntity 
                {
                    RoleName = customer.Role.RoleName
                };
                _roleRepository.Create(roleEntity);

                var addressEntity = new AddressEntity
                {
                    StreetName = customer.Address.StreetName,
                    PostalCode = customer.Address.PostalCode,
                    City = customer.Address.City
                };
                _addressRepository.Create(addressEntity);

                var customerEntity = new CustomerEntity
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    RoleId = roleEntity.Id,
                    AddressId = addressEntity.Id,
                };
                customerEntity = _customerRepository.Create(customerEntity);
                return customerEntity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
            
        }

        public CustomerEntity GetCustomerByEmail(string email)
        {
            try
            {
                var customerEntity = _customerRepository.GetSingle(x => x.Email == email);
                return customerEntity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
            
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            try
            {
                var customers = _customerRepository.GetAll();
                return customers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
            
        }

        public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
        {
            try
            {
                var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
                return updatedCustomerEntity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
            
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.Delete(x => x.Id == id);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
