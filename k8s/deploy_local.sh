# Define variables
RELEASE_NAME=weather

# Build & push images
TAG="localhost:5001/$RELEASE_NAME-backend:latest"
docker build -t $TAG -f ../Dnw.Weather.Tye.Backend/Dockerfile ../Dnw.Weather.Tye.Backend
docker push $TAG

TAG="localhost:5001/$RELEASE_NAME-frontend:latest"
docker build -t $TAG -f ../Dnw.Weather.Tye.Frontend/Dockerfile ../Dnw.Weather.Tye.Frontend
docker push $TAG

# Deploy to k8s
helm upgrade "$RELEASE_NAME" ./helm --install --namespace "$RELEASE_NAME" --create-namespace

# Restart the deployments
kubectl rollout restart "deployment/frontend" -n "$RELEASE_NAME"
kubectl rollout restart "deployment/backend" -n "$RELEASE_NAME"