# HoneyPot 
This web service accepts all http requests and replies with an infinite stream of text "Not Found" every 5 seconds.
The implementation is in a middleware so that it captures all incoming requests. A test controller is left in the project to show that requests never get to the test endpoint.

## Limitations 
The service is self-hosted via Kestrel and the default number of concurrent connections is set to Unlimited, hence, there's no limit from the application, the service is only limited by the hosting hardware.
 
The service is hosted in a Linux container. The number of incoming TCP connections from different source IPs to port 80 is limited by the file descriptors. This limit is configurable, but is probably beyond the scope of this exercise. But it [can be done](https://www.linkedin.com/pulse/ec2-tuning-1m-tcp-connections-using-linux-stephen-blum).

## Assumptions
 - The original requirement doesn't say anything about POST requests. The solution handles POST requests as well. To make it only handle GET requests, simply add condition `if (context.Request.Method = "GET")` to the middleware.
 - The dockerfile only exposes port 80. This is assuming that SSL termination is done (at the load balancer, for example) before the requests get to this service. 
 
## Instructions 
Please follow these steps to test this service.
 - Get [docker desktop](https://docs.docker.com/get-docker/) if not present.
 - From the repository's root folder, run `docker build -t 01 HoneyPot/HoneyPot` to build the container.
 - Run `docker run -p 8081:80 01` to start the container.
 - Run `curl https://localhost:8081` to test the service. 

**Note**: the service was tested on a Windows computer, but it should work on other platforms, too.
