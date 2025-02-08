FROM postgres:latest

ENV POSTGRES_DB=bunker \
    POSTGRES_PASSWORD=Nassa123,

HEALTHCHECK --interval=10s --timeout=5s --retries=5 CMD pg_isready -U postgres