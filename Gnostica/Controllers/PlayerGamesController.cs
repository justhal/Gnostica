using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gnostica.Data;
using Gnostica.Models;

namespace Gnostica.Controllers
{
    public class PlayerGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerGame.Include(p => p.Game).Include(p => p.Player);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayerGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerGame = await _context.PlayerGame
                .Include(p => p.Game)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerGame == null)
            {
                return NotFound();
            }

            return View(playerGame);
        }

        // GET: PlayerGames/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Name");
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "Name");
            return View();
        }

        // POST: PlayerGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerID,GameID,PieceColor,Eliminated")] PlayerGame playerGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Name", playerGame.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "Name", playerGame.PlayerID);
            return View(playerGame);
        }

        // GET: PlayerGames/Edit/5
        public async Task<IActionResult> Edit(int? playerID, int? gameID)
        {
            if (playerID == null && gameID == null)
            {
                return NotFound();
            }

            var playerGame = await _context.PlayerGame.FindAsync(playerID, gameID);
            if (playerGame == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Name", playerGame.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "Name", playerGame.PlayerID);
            return View(playerGame);
        }

        // POST: PlayerGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int playerID, int gameID, [Bind("PlayerID,GameID,PieceColor,Eliminated")] PlayerGame playerGame)
        {
            if (playerID != playerGame.PlayerID && gameID != playerGame.GameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerGameExists(playerGame.PlayerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Name", playerGame.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "Name", playerGame.PlayerID);
            return View(playerGame);
        }

        // GET: PlayerGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerGame = await _context.PlayerGame
                .Include(p => p.Game)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerGame == null)
            {
                return NotFound();
            }

            return View(playerGame);
        }

        // POST: PlayerGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerGame = await _context.PlayerGame.FindAsync(id);
            _context.PlayerGame.Remove(playerGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PlayerGames/AddPlayerToGame
        public IActionResult AddPlayerToGame()
        {
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Name");
            ViewData["PlayerID"] = new SelectList(_context.Players, "ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetValidPlayersCanJoinGame(int? gameID)
        {
            var game = await _context.Games
                .Include(g => g.PlayerGames)
                .FirstOrDefaultAsync(g => g.ID == gameID);
            var players = _context.Players.ToList();
            foreach(var playerGame in game.PlayerGames)
            {
                players.Remove(playerGame.Player);
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Name");
            ViewData["PlayerID"] = new SelectList(players, "ID", "Name");
            return PartialView("_ValidPlayerListPartial");
        }

        private bool PlayerGameExists(int id)
        {
            return _context.PlayerGame.Any(e => e.PlayerID == id);
        }
    }
}
