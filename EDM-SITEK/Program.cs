using EDM_SITEK;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
FIAS_API fiasapi = new FIAS_API();
fiasapi.init();
app.Run( 
    
    );
