// using Mapster;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;

// namespace API.Presentation.API.Mapster
// {
//     public class GlobalMapProfile 
//     {
//         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//         {
//             if (env.IsDevelopment())
//             {
//                 app.UseDeveloperExceptionPage();
//             }

//             TypeAdapterConfig<string, string>().NewConfig()
//                 .Map(str => (str != null) ? str.Trim() : str);  
//         }
//     }
// }