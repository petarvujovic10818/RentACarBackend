using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using rentacar.data;
using rentacar.dtos;
using rentacar.helpers;
using rentacar.interfaces;
using rentacar.models;

namespace rentacar.repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext _context;

        public CarRepository(ApplicationDBContext context)
        {
            _context = context;   
        }

        public async Task<bool> carExists(int id)
        {
            return await _context.Cars.AnyAsync(c => c.id == id);
        }

        public async Task<Car> createCar(Car carModel)
        {
             await _context.Cars.AddAsync(carModel);
             await _context.SaveChangesAsync();
             return carModel;
        }

        public async Task<Car?> deleteCar(int id)
        {
            var carModel = await _context.Cars.FirstOrDefaultAsync(x => x.id == id);
            if(carModel == null) return null;

            _context.Cars.Remove(carModel);
            await _context.SaveChangesAsync();
            return carModel;

        }

        public async Task<Car?> getCarById(int id)
        {
            return await _context.Cars.Include(f => f.feedbacks).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Car>> getCars(QueryObject query)
        {

            var cars = _context.Cars.Include(f => f.feedbacks).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.marka)){
                cars = cars.Where(c => c.marka.Contains(query.marka));
            }

            if(!string.IsNullOrWhiteSpace(query.model)){
                cars = cars.Where(c => c.model.Contains(query.model));
            }

            if(!string.IsNullOrWhiteSpace(query.zapreminaMotoraRange)){
                string[] x = query.zapreminaMotoraRange.Split("-");
                cars = cars.Where(c => c.zapreminaMotora >= int.Parse(x[0]) && c.zapreminaMotora <= int.Parse(x[1]));
            }

            if(!string.IsNullOrWhiteSpace(query.cijenaRange)){
                string[] x = query.cijenaRange.Split("-");
                cars = cars.Where(c => c.zapreminaMotora >= int.Parse(x[0]) && c.zapreminaMotora <= decimal.Parse(x[1]));
            }

            if(!string.IsNullOrWhiteSpace(query.sortBy)){
                switch(query.sortBy){
                    case "marka": {
                        cars = query.isDescending ? cars.OrderByDescending(y => y.marka) : cars.OrderBy(y => y.marka);
                        break;
                    }
                    case "karoserija": {
                        cars = query.isDescending ? cars.OrderByDescending(y => y.karoserija) : cars.OrderBy(y => y.karoserija);
                        break;
                    }
                    case "model": {
                        cars = query.isDescending ? cars.OrderByDescending(y => y.model) : cars.OrderBy(y => y.model);
                        break;
                    }
                    case "gorivo": {
                        cars = query.isDescending ? cars.OrderByDescending(y => y.gorivo) : cars.OrderBy(y => y.gorivo);
                        break;
                    }
                    case "zapreminaMotora": {
                        cars = query.isDescending ? cars.OrderByDescending(y => y.zapreminaMotora) : cars.OrderBy(y => y.zapreminaMotora);
                        break;
                    }
                    case "jacinaMotora": {
                        cars = query.isDescending ? cars.OrderByDescending(y => y.jacinaMotora) : cars.OrderBy(y => y.jacinaMotora);
                        break;
                    }
                    case "cijena": {
                        cars = query.isDescending ? cars.OrderByDescending(y => y.cijena) : cars.OrderBy(y => y.cijena);
                        break;
                    }
                    
                }
            }

            var skipNumber = (query.pageNumber - 1) * query.pageSize;


            return await cars.Skip(skipNumber).Take(query.pageSize).ToListAsync();
            // return await _context.Cars.Include(f => f.feedbacks).ToListAsync();
        }

        public async Task<Car?> updateCar(int id, UpdateCarDTO updateCarDTO)
        {
            var carModel = await _context.Cars.Include(f => f.feedbacks).FirstOrDefaultAsync(x => x.id == id);
            if(carModel == null) return null;

            carModel.marka = updateCarDTO.marka;
            carModel.karoserija = updateCarDTO.karoserija;
            carModel.gorivo = updateCarDTO.gorivo;
            carModel.zapreminaMotora = updateCarDTO.zapreminaMotora;
            carModel.jacinaMotora = updateCarDTO.jacinaMotora;

            await _context.SaveChangesAsync();
            return carModel;
        }
    }
}