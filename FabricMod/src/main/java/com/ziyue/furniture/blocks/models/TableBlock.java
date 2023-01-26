package com.ziyue.furniture.blocks.models;

import net.fabricmc.fabric.api.object.builder.v1.block.FabricBlockSettings;
import net.minecraft.block.*;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.shape.VoxelShape;
import net.minecraft.util.shape.VoxelShapes;
import net.minecraft.world.BlockView;

import static net.minecraft.util.shape.VoxelShapes.cuboid;

/**
 * @author ZiYueCommentary
 */

public class TableBlock extends Block {
    public TableBlock(Settings settings) {
        super(settings);
    }

    /*
            下面是价值三天的代码（bushi
            实际上为了做出来一个自定义的碰撞箱，试了kotlin环境，然后参考了MrCrayfish的家具模组（话说我为什么参考一个forge模组的源码
            最后找了Blockus的源码，在模组引用的文件中找到了多碰撞箱结合的代码
            下面TABLE_TOP就是桌面，TABLE_POST就是桌子的柱子，TABLE_BOTTOM就是桌子的底部那个小方块
            这三个在模型文件中分别名为top, post, bottom
            注册方块的时候将new Block()改为new TableBlock()即可

            别人开源就是为了给我们复制粘贴！（不是
        */
    @Override
    //实际上自定义碰撞箱就是把多个长方形碰撞箱结合到一起，使用VoxelShapes.union就可以结合碰撞箱
    public VoxelShape getOutlineShape(BlockState state, BlockView view, BlockPos pos, ShapeContext context) {
        //桌面
        final VoxelShape TABLE_TOP = cuboid(0f, 0.875f, 0f, 1f, 1f, 1f);
        //桌柱子
        final VoxelShape TABLE_POST = cuboid(0.4375f, 0f, 0.4375f, 0.5635f, 0.875f, 0.5625f);
        //桌底部
        final VoxelShape TABLE_BOTTOM = cuboid(0.375f, 0f, 0.375f, 0.625f, 0.0625, 0.625f);

        //这个返回语句可以将碰撞箱结合，例如此处写了三个碰撞箱，这三个结合起来就是桌子的自定义碰撞箱
        return VoxelShapes.union(TABLE_TOP, TABLE_POST, TABLE_BOTTOM);
    }
}
