using JudgeSystem.App.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudgeSystem.App.Models.Contests;
using JudgeSystem.App.Data;
using AutoMapper.QueryableExtensions;
using JudgeSystem.App.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JudgeSystem.App.Services
{
    public class ContestService : IContestService
    {
        private readonly JudgeSystemDbContext db;

        public ContestService(JudgeSystemDbContext db)
        {
            this.db = db;
        }

        public ICollection<ContestListModel> All()
        {
            var results = db.Contests.ProjectTo<ContestListModel>().ToList();

            return results;
        }

        public ICollection<ContestSelectModel> AllForSelect()
        {
            var results = db.Contests.ProjectTo<ContestSelectModel>().ToList();

            return results;
        }

        public void Create(string contestName, string creatorEmail)
        {
            var contest = new Contest()
            {
                ContestName = contestName,
                CreatorEmail = creatorEmail
            };

            this.db.Contests.Add(contest);
            this.db.SaveChanges();
        }

        public void Delete(int contestId)
        {
            var contest = this.db.Contests.First(c => c.Id == contestId);

            this.db.Remove(contest);
            this.db.SaveChanges();
        }

        public void Edit(int contestId, string contestName)
        {
            var contest = this.GetById(contestId);

            contest.ContestName = contestName;
            this.db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.db.Contests.Any(c => c.Id == id);
        }

        public Contest GetById(int id)
        {
            var contest = this.db.Contests.First(c => c.Id == id);

            return contest;
        }

        public bool UserCanEditDelete(int id, string name, bool isAdmin)
        {
            if (isAdmin)
            {
                return true;
            }

            var contest = this.db.Contests.First(c => c.Id == id);

            if (name == contest.CreatorEmail)
            {
                return true;
            }

            return false;
        }
    }
}