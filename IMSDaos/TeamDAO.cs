﻿using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDaos
{
    public class TeamDAO
    {
        private readonly AppDbContext db = null;
        private static TeamDAO instance = null;

        public TeamDAO()
        {
            db = new AppDbContext();
        }
        public static TeamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeamDAO();
                }
                return instance;
            }
        }

        public Team GetTeamById(int teamId)
        {
            return db.Teams.FirstOrDefault(x => x.TeamId == teamId);
        }

        public Team GetTeamByName(string teamName)
        {
            return db.Teams.FirstOrDefault(y => y.TeamName == teamName);
        }
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await db.Teams.ToListAsync();
        }
        public List<Team> GetAllTeams()
        {
            return db.Teams.ToList();
        }
        public void AddTeam(Team team)
        {
            Team newTeam = GetTeamById(team.TeamId);
            if (newTeam == null)
            {
                db.Teams.Add(team);
                db.SaveChanges();
            }
        }
        public void RemoveTeam(int teamId)
        {
            Team team = GetTeamById(teamId);
            if (team != null)
            {
                db.Teams.Remove(team);
                db.SaveChanges();
            }
        }

        public async Task<Team> GetTeamByIdAsync(int teamId)
        {
            return await db.Teams.FirstOrDefaultAsync(x => x.TeamId == teamId);
        }
        public void UpdateTeam(Team team)
        {
            var existingTeam = db.Teams.FirstOrDefault(x => x.TeamId == team.TeamId);
            if (existingTeam != null)
            {
                existingTeam.TeamName = team.TeamName;
                db.Teams.Update(existingTeam);
                db.SaveChanges();
            }
        }
        public async Task UpdateTeamAsync(Team team)
        {
            var existingTeam = db.Teams.FirstOrDefault(x => x.TeamId == team.TeamId);
            if (existingTeam != null)
            {
                existingTeam.TeamName = team.TeamName;
                db.Teams.Update(existingTeam);
                db.SaveChanges();
            }
        }
    }
}
