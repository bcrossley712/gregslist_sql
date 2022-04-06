using System;
using System.Collections.Generic;
using gregslist_sql.Models;
using gregslist_sql.Repositories;

namespace gregslist_sql.Services
{
  public class CarsService
  {
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    internal List<Car> GetAll()
    {
      return _repo.Get();
    }

    internal Car GetById(int id)
    {
      Car found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Car Create(Car body)
    {

      return _repo.Create(body);
    }

    internal Car Update(Car body)
    {
      Car original = GetById(body.Id);
      original.Color = body.Color ?? original.Color;
      original.Description = body.Description ?? original.Description;
      original.ImgUrl = body.ImgUrl ?? original.ImgUrl;
      original.Make = body.Make ?? original.Make;
      original.Model = body.Model ?? original.Model;
      original.Price = body.Price != null ? body.Price : original.Price;
      original.Year = body.Year != null ? body.Year : original.Year;
      _repo.Update(original);
      return original;
    }

    internal void Delete(int id)
    {
      Car found = GetById(id);
      _repo.Delete(id);
    }
  }
}