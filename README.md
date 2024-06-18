# IdentityServer with OpenTelemetry

This is a reproduction of the issue I'm facing with OpenTelemetry and IdentityServer.

Services used by the docker-compose file:
- `opentelemetry-collector` to collect traces and metrics.
- `grafana` to visualize the traces and metrics.
- `tempo` to store the traces.
- `prometheus` to store the metrics.

## Running the project

1. Run `docker-compose up -d` to start the telemetry stack.
    - Runs `opentelemetry-collector` on port `4317` with GRPC.
    - Runs `grafana` on port `3000` (passwordless)
2. Run the IdentityServer project through your IDE or the console.
3. Visit some of the endpoints to generate traces.
    - You can use the swagger to send a few requests: http://localhost:5000/swagger/index.html
    - Visit the discovery endpoint manually: http://localhost:5000/.well-known/openid-configuration because it does not show up in the swagger.
4. Visit Grafana on http://localhost:3000/explore and explore the traces in `Tempo`.
