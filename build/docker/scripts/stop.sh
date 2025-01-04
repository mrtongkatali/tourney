#!/bin/bash

function getScriptDir() {
  local DIR="${0%/*}"
  cd "$DIR" && pwd -P
}

DOCKER_SCRIPTS_DIR=$(getScriptDir)
BASE_PATH=$(dirname "$(dirname "$(dirname "$DOCKER_SCRIPTS_DIR")")")

docker compose --file "$BASE_PATH"/docker-compose.yml down