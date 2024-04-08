using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.data;
using rentacar.dtos;
using rentacar.interfaces;
using rentacar.models;

namespace rentacar.mappers
{
    public static class OrderMapper
    {   
       public static OrderDTO orderToDTO(this Order order){
        return new OrderDTO{
            createdOn = order.createdOn,
            datumPocetka = order.datumPocetka,
            datumKraja = order.datumKraja,
            bodovi = order.bodovi,
            cijena = order.cijena,
            car = order?.car?.toCarDTO()
            // user = null,
            // car = order.car.
        };
       } 

       public static Order dtoToModelOrder(this CreateOrderDTO dto){
        return new Order{
            createdOn = dto.createdOn,
            datumPocetka = dto.datumPocetka,
            datumKraja = dto.datumKraja,
            bodovi = dto.bodovi,
            cijena = dto.cijena,
            userId = dto.userId,
            carId = dto.carId
        };
       }

       
    }
}