﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampus.API.Data;
using SmartCampus.API.Models;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        return await _context.Bookings.Include(b => b.User).Include(b => b.Service).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = await _context.Bookings.Include(b => b.User).Include(b => b.Service).FirstOrDefaultAsync(b => b.BookingId == id);
        if (booking == null) return NotFound();
        return booking;
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBooking(int id, Booking booking)
    {
        if (id != booking.BookingId) return BadRequest();
        _context.Entry(booking).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return NotFound();
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}