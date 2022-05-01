package com.tamcode.mycardcollection;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface CardAPI {

    @GET("v3/fc475d0b-b395-4590-a82b-5fb005d66224")
    Call<List<Pokemon>> getPokemon();
}
