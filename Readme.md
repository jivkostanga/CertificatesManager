# CertificatesManager example

This is a simple example for generationg certificates, use them and audit usage.

## Starting with docker compose

Start project docker-compose

Open in browser http://localhost:3000/swagger/

## Adding EF migration

```sh
dotnet ef migrations add Initial -p .\CertificatesManager.Infrastructure\CertificatesManager.Infrastructure.csproj -s .\CertificatesManager.Api\CertificatesManager.Api.csproj -o Data/Migrations
```

## Entities class diagram

![Entities class diagram](https://cdn-0.plantuml.com/plantuml/png/ZOz12i90303lUKK-q1SeMEf9H1741sntOmcahMooXLBxTwk8K1KqXq1W9Z2vcekMQW4lJXKBfxHh0maCWDDSKYdiKTgcmat00Iko1UfzZJ32qrfJD3wpTqPpJotoP1uYTyveI_tRXs_iu_eBFL9a9_jKbnH_qYiyAOMYdwIEFNsclD9nUSsoMHD0Jar8jTm0)

## Sequence diagram generate certificates endpoint

![Sequence diagram generate certificates endpoint](https://cdn-0.plantuml.com/plantuml/png/fP8nIyH044Rx-nLJQY48Og65t171wXfFqNQo-P9Rt9sSCnCz_xq915p1W6Azyzw-PMTjpkf3JdG7WRA3AgZ7DWPssCfUeXnOETFEFnB8N6EOviiJl0wGW2tCkCC3Zhv9iPCCSGeGXwwUK3yQbCvkIl-MPGHqSuXq_HLmGQ5C-7d-ksW7VOi1XQLQKCoJ4_zyUNvLdCnahuMbBA6Jm2aP-JxQsEWnmqvNIvB5m7lue4BTV4DJNh4GUbjNlJYEFkARfY71-n-fgiyvEeKzImSZxwbXvvfj2LxwfBa-HNFgMng9o8bao3NKgErrYYiVzwkVdBVZl_urf9bMynC0)

