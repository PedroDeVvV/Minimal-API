﻿using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Database;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndpointsMusicas(this WebApplication app)
        {

            app.MapGet("Musicas", ([FromServices] DAL<Musica> dal) =>
            {
                return Results.Ok(dal.Listar());
            });

            app.MapGet("Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
            {
                var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                return Results.Ok(dal.Listar());
            });

            app.MapPost("Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.nome);
                dal.Adicionar(musica);
                return Results.Created("/Musica", musica);
            });

            app.MapDelete("Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
            {
                var musicaEncontrada = dal.RecuperarPor(a => a.Id == id);
                if (musicaEncontrada is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(musicaEncontrada);
                return Results.NoContent();
            });

            app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
            {
                var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musicaRequestEdit.Id);
                if (musicaAAtualizar is null)
                {
                    return Results.NotFound();
                }
                musicaAAtualizar.Nome = musicaRequestEdit.nome;
                musicaAAtualizar.AnoLancamento = musicaRequestEdit.anoLancamento;

                dal.Atualizar(musicaAAtualizar);
                return Results.Ok();
            });

        }
        private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
        {
            return musicaList.Select(a => EntityToResponse(a)).ToList();
        }

        private static MusicaResponse EntityToResponse(Musica musica)
        {
            return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome);
        }
    }
}