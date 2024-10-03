A sample API designed for Amplifund's technical interview process.
Simply run the visual studio solution file in VS2022, and a Swagger page will be presented
/getFloop/{floopId}
  Returns Floop items in In-memory database. By default, there are two items in the DB, with ID values
  1 and 2
/addFloop
  Adds floop to in memory database. Default object is provided by Swagger but if you would like to call via postman, the 
  object format is: 
  {
  "floopName": "string",
  "floopType": "string",
  "floopSafetyCode": "string",
  "floopValue": 0
  }
  Returns ID value of floop added if successful, -1 if error occurs
/testClient
  Sends a Floop Request to our RestClient. Since we aren't actually connecting to anything, 
  this is just showing how we can interact with Http response and format requests.
  Send a request with testFlag true to get a valid response, and testFlag false to get an error response
/deleteFloop/{floopId}
  Removes floop with matching ID from DB. Returns true if successful, false if failure
