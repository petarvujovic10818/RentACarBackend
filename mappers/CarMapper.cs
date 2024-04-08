using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.dtos;
using rentacar.models;

namespace rentacar.mappers
{
    public static class CarMapper
    {
        public static UpdateCarDTO toCarDTO(this Car carModel){
            return new UpdateCarDTO{
                marka = carModel.marka,
                model = carModel.model,
                karoserija = carModel.karoserija,
                gorivo = carModel.gorivo,
                zapreminaMotora = carModel.zapreminaMotora,
                jacinaMotora = carModel.jacinaMotora,
                cijena = carModel.cijena

            };
        }

        public static CarDTO carToReadDTO(this Car carModel){
            return new CarDTO{
                marka = carModel.marka,
                model = carModel.model,
                karoserija = carModel.karoserija,
                gorivo = carModel.gorivo,
                zapreminaMotora = carModel.zapreminaMotora,
                jacinaMotora = carModel.jacinaMotora,
                cijena = carModel.cijena,
                feedbacks = carModel.feedbacks.Select(f => f.toNoCarDTO()).ToList() //dont show car in feedback
            };
        }

        public static Car dtoToModel(this UpdateCarDTO dto){
            return new Car{
                marka = dto.marka,
                model = dto.model,
                karoserija = dto.karoserija,
                gorivo = dto.gorivo,
                zapreminaMotora = dto.zapreminaMotora,
                jacinaMotora = dto.jacinaMotora,
                cijena = dto.cijena
            };
        }
    }
}