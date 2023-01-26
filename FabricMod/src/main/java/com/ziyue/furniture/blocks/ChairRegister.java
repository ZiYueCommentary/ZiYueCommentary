package com.ziyue.furniture.blocks;

import com.ziyue.furniture.blocks.models.ChairBlock;
import net.fabricmc.fabric.api.object.builder.v1.block.FabricBlockSettings;
import net.minecraft.block.Block;
import net.minecraft.block.Blocks;

public class ChairRegister {
    public static final Block OAK_CHAIR = new ChairBlock(FabricBlockSettings.copyOf(Blocks.OAK_WOOD));
}
