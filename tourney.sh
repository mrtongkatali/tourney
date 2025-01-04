#!/usr/bin/env bash

function getScriptDir() {
  local DIR="${0%/*}"
  cd "$DIR" && pwd -P
}

BASE_PATH=$(getScriptDir)
DOCKER_SCRIPTS_DIR="$BASE_PATH/build/docker/scripts"

if [[ "$1" == "ps" || $# -eq 0 ]]; then
  docker compose --file "$BASE_PATH"/docker-compose.yml ps

elif [ "$1" == "start" ] || [ "$1" == "up" ]; then
  shift 1
  "$DOCKER_SCRIPTS_DIR"/start.sh "$@"

elif [ "$1" == "stop" ]; then
  shift 1
  "$DOCKER_SCRIPTS_DIR"/stop.sh "$@"

elif [ "$1" == "bash" ] && [ "$2" == "api" ]; then
  echo "Logged in to Webhost API.."

  docker exec -it 7lingo_api sh

elif [ "$1" == "logs" ]; then
  echo "Showing API logs..."

  docker compose --file "$BASE_PATH"/docker-compose.yml logs -f
  
fi
