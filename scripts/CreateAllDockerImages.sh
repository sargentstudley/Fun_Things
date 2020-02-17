docker build -t localhost/participantapi:latest ./pin_api/participantapi --no-cache
docker build -t localhost/pinmentor:latest ./pin_ui/pinmentor --no-cache
docker system prune -f