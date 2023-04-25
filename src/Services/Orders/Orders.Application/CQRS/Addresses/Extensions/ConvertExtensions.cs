using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Addresses.Extensions
{
    public static class ConvertExtensions
    {
        public static AddressDto Map(this Address address)
        {
            return new AddressDto
            {
                District = address.District,
                Line = address.Line,
                Province = address.Province,
                Street = address.Street,
                ZipCode = address.ZipCode
            };
        }
        public static Address MapDto(this AddressDto addressDto)
        {
            return new Address(addressDto.Province, addressDto.District, addressDto.Street, addressDto.ZipCode, addressDto.Line);
        }
    }
}
