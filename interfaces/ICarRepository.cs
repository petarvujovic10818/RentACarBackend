using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.dtos;
using rentacar.helpers;
using rentacar.models;

namespace rentacar.interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> getCars(QueryObject query);
        Task<Car?> getCarById(int id);
        Task<Car> createCar(Car carModel);
        Task<Car?> updateCar(int id, UpdateCarDTO updateCarDTO);
        Task<Car?> deleteCar(int id);

        Task<bool> carExists(int id);
    }
}