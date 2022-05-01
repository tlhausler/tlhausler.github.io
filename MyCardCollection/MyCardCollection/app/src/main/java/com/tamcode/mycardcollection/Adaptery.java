package com.tamcode.mycardcollection;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import java.util.List;

public class Adaptery extends RecyclerView.Adapter<Adaptery.ViewHolder> {

    private Context mContext;
    private List<Pokemon> pokemonList;

    public Adaptery(Context mContext, List<Pokemon> pokemonList) {
        this.mContext = mContext;
        this.pokemonList = pokemonList;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v;
        LayoutInflater layoutInflater = LayoutInflater.from(mContext);
        v = layoutInflater.inflate(R.layout.pokemon_item, parent, false);
        return new ViewHolder(v);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        holder.id.setText(pokemonList.get(position).getId());
        holder.cardName.setText(pokemonList.get(position).getName());

        Glide.with(mContext)
                .load(pokemonList.get(position).getImage())
                .into(holder.imgCard);

    }

    @Override
    public int getItemCount() {
        return pokemonList.size();
    }


    public static class ViewHolder extends RecyclerView.ViewHolder {

        TextView cardName;
        TextView id;
        ImageView imgCard;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);

            cardName = itemView.findViewById(R.id.pokeName);
            id = itemView.findViewById(R.id.pokeDexNumber);
            imgCard = itemView.findViewById(R.id.cardImg);
        }
    }

}
