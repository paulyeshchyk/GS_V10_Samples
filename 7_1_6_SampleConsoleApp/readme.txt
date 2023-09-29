follow guide https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows
and this https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-7.0


//build
docker build -t counter-image -f Dockerfile .

//single run
docker run -it --rm counter-image

//signle run with argument
docker run -it --rm counter-image 3

//create container
docker create --name core-counter counter-image

//start container
docker start core-counter


// stop container
docker stop core-counter

// attach to container
docker attach --sig-proxy=false core-counter

//remove container
docker rm core-counter

//list of containers
docker ps -a

//remove image
docker rmi counter-image:latest

//remove dotnet image
docker rmi mcr.microsoft.com/dotnet/aspnet:7.0
