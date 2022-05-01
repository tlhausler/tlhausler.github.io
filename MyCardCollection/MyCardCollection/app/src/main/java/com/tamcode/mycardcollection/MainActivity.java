package com.tamcode.mycardcollection;

import static android.content.ContentValues.TAG;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class MainActivity extends AppCompatActivity {

    RecyclerView recyclerView;
    List<Pokemon> pokemonList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        recyclerView = findViewById(R.id.recyclerView);
        pokemonList = new ArrayList<>();

        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl("https://run.mocky.io/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        CardAPI cardAPI = retrofit.create(CardAPI.class);

        Call<List<Pokemon>> call = cardAPI.getPokemon();

        call.enqueue(new Callback<List<Pokemon>>() {
            @Override
            public void onResponse(@NonNull Call<List<Pokemon>> call, @NonNull Response<List<Pokemon>> response) {

                if (response.code() != 200) {
                    return;
                }
                List<Pokemon> pokeResponse = response.body();

                if (pokeResponse != null) {
                    pokemonList.addAll(pokeResponse);
                }

                PutDataIntoRecyclerView(pokemonList);

            }

            @Override
            public void onFailure(@NonNull Call<List<Pokemon>> call, @NonNull Throwable t) {
                Log.d(TAG, "onFailure: " + t);
            }
        });
    }

    private void PutDataIntoRecyclerView(List<Pokemon> pokemonList) {
        Adaptery pokeAdapter = new Adaptery(this, pokemonList);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        recyclerView.setAdapter(pokeAdapter);
    }
}