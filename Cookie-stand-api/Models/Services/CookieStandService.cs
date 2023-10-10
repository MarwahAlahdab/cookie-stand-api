using CookieStandApi.Data;
using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.DTOs;
using CookieStandAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CookieStandService : ICookieStand
{
    private readonly CookieStandDbContext _context;

    public CookieStandService(CookieStandDbContext context)
    {
        _context = context;
    }

    public async Task<CookieStandDto> Create(CookieStandDto cookieStandDto)
    {
        var cookieStandToAdd = new CookieStand
        {
            Location = cookieStandDto.Location,
            Description = cookieStandDto.Description,
            Minimum_Customers_Per_Hour = cookieStandDto.Minimum_Customers_Per_Hour,
            Maximum_Customers_Per_Hour = cookieStandDto.Maximum_Customers_Per_Hour,
            Average_Cookies_Per_Sale = cookieStandDto.Average_Cookies_Per_Sale,
            Owner = cookieStandDto.Owner
        };

        await _context.CookieStands.AddAsync(cookieStandToAdd);
        await _context.SaveChangesAsync();

        cookieStandDto.Id = cookieStandToAdd.Id;
        cookieStandDto.HourlySales = await GenerateHourlySales(cookieStandToAdd.Id, cookieStandToAdd.Minimum_Customers_Per_Hour, cookieStandToAdd.Maximum_Customers_Per_Hour, cookieStandToAdd.Average_Cookies_Per_Sale);

        return cookieStandDto;
    }

    public async Task Delete(int id)
    {
        var existingCookieStand = await _context.CookieStands.FindAsync(id);
        if (existingCookieStand != null)
        {
            _context.CookieStands.Remove(existingCookieStand);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<CookieStandDto>> GetCookieStands()
    {
        var cookieStands = await _context.CookieStands.Include(cs => cs.HourlySales).ToListAsync();
        var cookieStandDtos = cookieStands.Select(cs => new CookieStandDto
        {
            Id = cs.Id,
            Location = cs.Location,
            Description = cs.Description,
            Minimum_Customers_Per_Hour = cs.Minimum_Customers_Per_Hour,
            Maximum_Customers_Per_Hour = cs.Maximum_Customers_Per_Hour,
            Average_Cookies_Per_Sale = cs.Average_Cookies_Per_Sale,
            Owner = cs.Owner,
            HourlySales = cs.HourlySales.Select(hs => hs.HourSale).ToList()
        }).ToList();

        return cookieStandDtos;
    }

    public async Task<CookieStandDto> GetCookieStandById(int id)
    {
        var cookieStand = await _context.CookieStands.Include(cs => cs.HourlySales).FirstOrDefaultAsync(cs => cs.Id == id);
        var cookieStandDto = new CookieStandDto
        {
            Id = cookieStand.Id,
            Location = cookieStand.Location,
            Description = cookieStand.Description,
            Minimum_Customers_Per_Hour = cookieStand.Minimum_Customers_Per_Hour,
            Maximum_Customers_Per_Hour = cookieStand.Maximum_Customers_Per_Hour,
            Average_Cookies_Per_Sale = cookieStand.Average_Cookies_Per_Sale,
            Owner = cookieStand.Owner,
            HourlySales = cookieStand.HourlySales.Select(hs => hs.HourSale).ToList()
        };
        return cookieStandDto;
    }

    public async Task<CookieStandDto> Update(int id, CookieStandDto cookieStandDto)
    {
        var existingCookieStand = await _context.CookieStands.FindAsync(id);

        if (existingCookieStand != null)
        {
            // Update properties
            existingCookieStand.Location = cookieStandDto.Location;
            existingCookieStand.Description = cookieStandDto.Description;
            existingCookieStand.Minimum_Customers_Per_Hour = cookieStandDto.Minimum_Customers_Per_Hour;
            existingCookieStand.Maximum_Customers_Per_Hour = cookieStandDto.Maximum_Customers_Per_Hour;
            existingCookieStand.Average_Cookies_Per_Sale = cookieStandDto.Average_Cookies_Per_Sale;
            existingCookieStand.Owner = cookieStandDto.Owner;

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        return cookieStandDto;
    }

    public async Task<List<int>> GenerateHourlySales(int CookieStandId, int Minimum_Customers_Per_Hour, int Maximum_Customers_Per_Hour, double Average_Cookies_Per_Sale)
    {
        var random = new Random();
        var hourlySalesList = new List<int>();

        for (int hour = 1; hour <= 14; hour++)
        {
            var customersThisHour = random.Next(Minimum_Customers_Per_Hour, Maximum_Customers_Per_Hour + 1);
            var cookiesSoldThisHour = (int)(customersThisHour * Average_Cookies_Per_Sale);

            hourlySalesList.Add(cookiesSoldThisHour);
        }

        return hourlySalesList;
    }
}
