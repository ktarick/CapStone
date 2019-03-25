﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs_Serve1.Models;

namespace Prs_Serve1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PrsDbContext _context;

        public RequestsController(PrsDbContext context)
        {
            _context = context;
        }


        // Request REVIEW or APPROVED
        [HttpPut("/api/Requests/Review/{id}")]
        public async Task<IActionResult> PutRequestReview(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if(request == null)
            {
                return NoContent();
            }            
            if(request.Total <= 50)
            {
                request.Status = "Approved";
            }
            else
            {
                request.Status = "Review";
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("/api/Requests/Approved/{id}")]
        public async Task<IActionResult> PutRequestApproved(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NoContent();
            }
                request.Status = "Approved";

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("/api/Requests/Rejected/{id}")]
        public async Task<IActionResult> PutRequestRejected(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NoContent();
            }
            request.Status = "Rejected";

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }

        // GET: api/Requests/
        [HttpGet("/api/Request/review")]
        public async Task<ActionResult<IEnumerable<Request>>> GetAllRequests()
        {
            var request = await _context.Requests.Where(req => req.Status == "Review").ToListAsync(); 
            return request;
        }
    }
}
