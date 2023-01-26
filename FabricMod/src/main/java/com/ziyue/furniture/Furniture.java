package com.ziyue.furniture;

import com.ziyue.furniture.blocks.ChairRegister;
import com.ziyue.furniture.blocks.TableRegister;
import com.ziyue.furniture.blocks.models.ChairBlock;
import net.fabricmc.api.ModInitializer;
import net.fabricmc.fabric.api.client.itemgroup.FabricItemGroupBuilder;
import net.fabricmc.fabric.api.event.player.UseBlockCallback;
import net.fabricmc.fabric.api.object.builder.v1.entity.FabricEntityTypeBuilder;
import net.minecraft.block.Block;
import net.minecraft.block.BlockState;
import net.minecraft.block.SlabBlock;
import net.minecraft.block.StairsBlock;
import net.minecraft.block.enums.BlockHalf;
import net.minecraft.block.enums.SlabType;
import net.minecraft.entity.EntityDimensions;
import net.minecraft.entity.EntityType;
import net.minecraft.entity.SpawnGroup;
import net.minecraft.entity.vehicle.MinecartEntity;
import net.minecraft.item.BlockItem;
import net.minecraft.item.Item;
import net.minecraft.item.ItemGroup;
import net.minecraft.item.ItemStack;
import net.minecraft.util.ActionResult;
import net.minecraft.util.Identifier;
import net.minecraft.util.math.Direction;
import net.minecraft.util.math.Vec3d;
import net.minecraft.util.registry.Registry;

public class Furniture implements ModInitializer {
	public static final String MOD_ID = "furniture";
	public static final ItemGroup FURNITURE_GROUP = FabricItemGroupBuilder.build(new Identifier(MOD_ID, "itemgroup"), () -> new ItemStack(TableRegister.OAK_TABLE));

	@Override
	public void onInitialize() {
		/*桌子*/
		//橡木桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "oak_table"), TableRegister.OAK_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "oak_table"), new BlockItem(TableRegister.OAK_TABLE, new Item.Settings().group(Furniture.FURNITURE_GROUP)));
		//云杉木桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "spruce_table"), TableRegister.SPRUCE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "spruce_table"), new BlockItem(TableRegister.SPRUCE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//白桦木桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "birch_table"), TableRegister.BIRCH_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "birch_table"), new BlockItem(TableRegister.BIRCH_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//丛林木桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "jungle_table"), TableRegister.JUNGLE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "jungle_table"), new BlockItem(TableRegister.JUNGLE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//金合欢木桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "acacia_table"), TableRegister.ACACIA_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "acacia_table"), new BlockItem(TableRegister.ACACIA_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//深色橡木桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "dark_oak_table"), TableRegister.DARK_OAK_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "dark_oak_table"), new BlockItem(TableRegister.DARK_OAK_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//绯红菌桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "crimson_table"), TableRegister.CRIMSON_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "crimson_table"), new BlockItem(TableRegister.CRIMSON_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//诡异菌桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "warped_table"), TableRegister.WARPED_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "warped_table"), new BlockItem(TableRegister.WARPED_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//圆石桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "cobblestone_table"), TableRegister.COBBLESTONE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "cobblestone_table"), new BlockItem(TableRegister.COBBLESTONE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//石桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "stone_table"), TableRegister.STONE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "stone_table"), new BlockItem(TableRegister.STONE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//花岗岩桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "granite_table"), TableRegister.GRANITE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "granite_table"), new BlockItem(TableRegister.GRANITE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//闪长岩桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "diorite_table"), TableRegister.DIORITE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "diorite_table"), new BlockItem(TableRegister.DIORITE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//安山岩桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "andesite_table"), TableRegister.ANDESITE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "andesite_table"), new BlockItem(TableRegister.ANDESITE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//石英桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "quartz_table"), TableRegister.QUARTZ_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "quartz_table"), new BlockItem(TableRegister.QUARTZ_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//砂岩桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "sandstone_table"), TableRegister.SANDSTONE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "sandstone_table"), new BlockItem(TableRegister.SANDSTONE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));
		//下界合金桌子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "netherite_table"), TableRegister.NETHERITE_TABLE);
		Registry.register(Registry.ITEM, new Identifier("furniture", "netherite_table"), new BlockItem(TableRegister.NETHERITE_TABLE, new Item.Settings().group(FURNITURE_GROUP)));

		/*椅子*/
		//橡木椅子
		Registry.register(Registry.BLOCK, new Identifier("furniture", "oak_chair"), ChairRegister.OAK_CHAIR);
		Registry.register(Registry.ITEM, new Identifier("furniture", "oak_chair"), new BlockItem(ChairRegister.OAK_CHAIR, new Item.Settings().group(FURNITURE_GROUP)));

		registry
	}
}