using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Base;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.Models.Models;

namespace TeaTimeDemo.DataAccess.Repositorys {
    public class QuestionsRepository: Repository<Questions>{
           private readonly ApplicationDbContext _db;
           
           public QuestionsRepository(ApplicationDbContext db): base(db) {
               _db = db;              
           }
    }
}