package com.ziyue.furniture.blocks;

import com.ziyue.furniture.blocks.models.TableBlock;
import net.fabricmc.fabric.api.object.builder.v1.block.FabricBlockSettings;
import net.minecraft.block.Block;
import net.minecraft.block.Blocks;

public class TableRegister{
    /*
        因为原木有斧子右键变成去皮原木的设定，所以方块数据引用原木会导致崩溃
        你可以引用去皮原木的数据来避免崩溃
    */
    public static final Block OAK_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.OAK_WOOD));
    public static final Block SPRUCE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.SPRUCE_WOOD));
    public static final Block BIRCH_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.BIRCH_WOOD));
    public static final Block JUNGLE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.JUNGLE_WOOD));
    public static final Block ACACIA_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.ACACIA_WOOD));
    public static final Block DARK_OAK_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.DARK_OAK_WOOD));
    public static final Block CRIMSON_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.CRIMSON_STEM));
    public static final Block WARPED_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.WARPED_STEM));
    public static final Block COBBLESTONE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.COBBLESTONE));
    public static final Block STONE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.STONE));
    public static final Block GRANITE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.GRANITE));
    public static final Block DIORITE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.DIORITE));
    public static final Block ANDESITE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.ANDESITE));
    public static final Block QUARTZ_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.QUARTZ_BLOCK));
    public static final Block SANDSTONE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.SANDSTONE));
    public static final Block NETHERITE_TABLE = new TableBlock(FabricBlockSettings.copyOf(Blocks.NETHERITE_BLOCK));
}