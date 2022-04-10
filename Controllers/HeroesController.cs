#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroAPI.Data;
using HeroAPI.Models;
using System.Text.Json;
using System.Net.Http;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroAPIContext _context;

        public HeroesController(HeroAPIContext context)
        {
            _context = context;
        }

        // GET: api/Heroes
        [HttpGet]
        public string GetHeroes()
        {
            Console.WriteLine("getting all...");

            //Use Eager loading to include all related entities (foreign keys)
            var heroList = _context.Heroes
                .Include(h => h.PrimaryFire).Include(h => h.SecondaryFire)
                .Include(h => h.Ability1).Include(h => h.Ability2).Include(h => h.Ultimate);

            return JsonSerializer.Serialize(heroList);
        }
        
        /*
        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
        {
            Console.WriteLine("getting...");
            return await _context.Heroes.ToListAsync();
        }
        */

        // GET: api/Heroes/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Hero>> GetHero(string name)
        {
            //Eagerly load first entity with inputted name
            var hero = await _context.Heroes.Include(h => h.PrimaryFire).Include(h => h.SecondaryFire)
                .Include(h => h.Ability1).Include(h => h.Ability2).Include(h => h.Ultimate).FirstAsync(h => h.Name == name);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(string id, Hero hero)
        {
            if (id != hero.Name)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            if (HeroExists(hero.Name)) return Conflict($"A Hero with name '{hero.Name}' already exists!");

            _context.Heroes.Add(hero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeroExists(hero.Name))
                {
                    Console.WriteLine($"Hero '{hero.Name}' already exists!");

                    return Conflict($"This hero already exists!");
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetHero", new { id = hero.Name }, hero);
            return Ok($"Successfully added Hero '{hero.Name}'");
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteHero(string name)
        {
            var hero = await _context.Heroes.Include(h => h.PrimaryFire).Include(h => h.SecondaryFire)
                .Include(h => h.Ability1).Include(h => h.Ability2).Include(h => h.Ultimate).FirstAsync(h => h.Name == name);

            //var hero = await _context.Heroes.FindAsync(name);
            if (hero == null)
            {
                return NotFound($"Hero '{name}' not found!");
            }

            _context.Weapons.Remove(hero.PrimaryFire);
            _context.Weapons.Remove(hero.SecondaryFire);

            _context.Abilities.Remove(hero.Ability1);
            _context.Abilities.Remove(hero.Ability2);
            _context.Abilities.Remove(hero.Ultimate);


            _context.Heroes.Remove(hero);


            await _context.SaveChangesAsync();

            //return NoContent();
            return Ok($"Hero: {name} successfully deleted!");
        }

        private bool HeroExists(string name)
        {
            return _context.Heroes.Any(h => h.Name == name);
        }
    }
}
