using AutoMapper;
using Gadget.api.Data;
using Gadget.api.Data.Helper;
using Gadget.api.Data.Models;
using Gadget.api.ENUM;
using Gadget.api.Utility;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gadget.api.Repository
{
    public class GadgetUserRepo : IGadgetUserRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<GadgetUserRepo> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GadgetUserRepo(AppDBContext context,UserManager<ApplicationUser> userManager, 
        RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager,
        ILogger<GadgetUserRepo> logger, IMapper mapper)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GadgetUserResponseModel?> CreateUser(CreateUserModel model)
        { 
           GadgetUserResponseModel res = new GadgetUserResponseModel();
            try
            {
                // validate email
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                    throw new Exception($"A user with same email '{model.Email}' already exists.");

                // List<ApplicationRole> roles = new List<ApplicationRole>();

                //     foreach(var role in model.roleName)
                //     {
                //     var theRole = await _roleManager.FindByNameAsync(role);
                //     roles.Add(theRole);
                //     }
                
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    CreatedBy = CustomClaimTypes.SuperAdmin,
                    DateCreated = DateTime.Now,
                    MiddleName = model.MiddleName,
                    Status = Status.Active,
                    Email = model.Email,
                    
                };
                string password = Utility.Extensions.Encrypt(model.Password);
                var result = await _userManager.CreateAsync(user, password);

                if(result.Succeeded)
                {
                   if(model.UserType == UserType.User)
                   {
                         // foreach(var r in roles)
                    await _userManager.AddToRoleAsync(user, CustomClaimTypes.User);  
                   }
                   await _userManager.AddToRoleAsync(user, CustomClaimTypes.SuperAdmin);
                       
                }
                GadgetUser gadgetUser = _mapper.Map<GadgetUser>(user);
                gadgetUser.Password = password;
                gadgetUser.UserType = model.UserType;
                await _context.GadgetUsers.AddAsync(gadgetUser);
                _context.SaveChanges();
                //res =  JObject.FromObject(user, new JsonSerializer {ReferenceLoopHandling= ReferenceLoopHandling.Ignore}).ToObject<GadgetUserResponseModel>();
                 res = _mapper.Map<GadgetUserResponseModel>(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error creating user: {ex.Message}");
            }

            
            return res;

        }

        public Task<List<GadgetUserResponseModel?>> GetAllUser()
        {
            throw new NotImplementedException();
        }
    }



    public interface IGadgetUserRepo
    {
        Task<GadgetUserResponseModel?> CreateUser(CreateUserModel model);

        Task<List<GadgetUserResponseModel?>> GetAllUser();
    }
}