﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LocalPass
{
    public class User
    {
       [Key]
       public int UserId { get;  set;}
       public  string Username { get; set; } 
       public string UserPassword { get; set; }
    }
}
