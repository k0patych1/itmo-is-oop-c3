using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type client_role as enum
        (
            'admin',
            'client'
        );

        create type transaction_type as enum
        (
            'deposit',
            'withdrawal'
        );

        create table admin_password
        (
            password text not null
        );

        INSERT INTO admin_password (password)
        VALUES ('12345');

        create table clients
        (
            client_id bigint primary key generated always as identity,
            client_name text not null,
            client_password text not null,
            money integer not null
        );

        create table transactions
        (
            transaction_id bigint primary key generated always as identity,
            client_id bigint not null references clients(client_id),
            transaction_date timestamp not null,
            transaction_amount integer not null,
            transaction_type transaction_type not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table clients;
        drop table transactions;
        drop table admin_password;

        drop type client_role;
        drop type transaction_type;
        """;
}