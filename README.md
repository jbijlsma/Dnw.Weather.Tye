# Intro

Example of using project tye: https://github.com/dotnet/tye  

The project tye sample can be found here:  

https://github.com/dotnet/tye/tree/main/samples  

# Create (initial) database migration

```shell
dotnet ef migrations add InitialCreate -p Dnw.Weather.Tye.Backend/Dnw.Weather.Tye.Backend.csproj
```

# Run with tye

```shell
tye run --dashboard
```

# Run with tye (in docker)

```shell
tye run --docker --dashboard
```

# Deploy to KinD k8s cluster

```shell
cd ./k8s
./deploy_local.sh
```

And to test if it is working:

```shell
k port-forward -n weather frontend-xxx 5050:5050
```

Note when using the deployment name you need the containerPort and not the port of the service as the port behind the :!

# Run Postgres locally (not necessary)

```shell
docker run --name postgresql -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -v /data:/var/lib/postgresql/data -d postgres
```

# Alternatives

Instead of tye for local development there are quite some alternatives to try out:

https://skaffold.dev/docs/workflows/debug/  
https://www.devspace.sh/
https://tilt.dev/ 

https://itnext.io/faster-net-development-on-kubernetes-with-skaffold-38b1d261eed5