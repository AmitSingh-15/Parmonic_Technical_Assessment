# Parmonic_Technical_Assessment
Parmonic Technical Assessment

2 ASP NET rate-limiting middleware

Write a custom ASP.NET Core middleware to perform IP-address based rate-limiting. The middleware should not allow more than 10 requests per second per IP address.

Hardcoding values is ok.


Amit S-  CustomMiddleware will be called after user authorisation. ConcurrentDictionary ApiCallsInMemory is thread-safe collection class, it will store to store key/value pairs,
in this case IP address (Key) and last time stamp and call counts. 

Method UpdateApiCallFor will update ApiCallsInMemory and GetPreviousApiCallByKey will get previous data from ApiCallsInMemory. 

Logic to check if request count is greater than 10 in last 10 seconds then return HttpStatusCode.TooManyRequests is added in Invoke method.