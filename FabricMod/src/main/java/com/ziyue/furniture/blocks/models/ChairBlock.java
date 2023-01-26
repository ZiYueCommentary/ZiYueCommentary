package com.ziyue.furniture.blocks.models;


import net.minecraft.block.Block;
import net.minecraft.block.BlockState;
import net.minecraft.block.HorizontalFacingBlock;
import net.minecraft.block.ShapeContext;
import net.minecraft.item.ItemPlacementContext;
import net.minecraft.state.StateManager;
import net.minecraft.state.property.Properties;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.math.Direction;
import net.minecraft.util.shape.VoxelShape;
import net.minecraft.util.shape.VoxelShapes;
import net.minecraft.world.BlockView;

import static net.minecraft.util.shape.VoxelShapes.cuboid;
import static net.minecraft.util.shape.VoxelShapes.union;

/**
 * @author ZiYueCommentary
 */

public class ChairBlock extends HorizontalFacingBlock {
    public ChairBlock(Settings settings) {
        super(settings);
        setDefaultState(this.stateManager.getDefaultState().with(Properties.HORIZONTAL_FACING, Direction.NORTH));
    }

    @Override
    protected void appendProperties(StateManager.Builder<Block, BlockState> stateManager) {
        stateManager.add(Properties.HORIZONTAL_FACING);
    }

    @Override
    /*
        这个部分与Fabric维基上写的不一样
        维基上的EntityContext在这里改为了ShapeContext
        （你觉得我会告诉你我是从TableBlock抄过来的吗
    */
    public VoxelShape getOutlineShape(BlockState state, BlockView view, BlockPos pos, ShapeContext context) {
        Direction dir = state.get(FACING);
            final VoxelShape LEG1 = cuboid(0.1875, 0, 0.1875, 0.3125,0.5, 0.3125);
            final VoxelShape LEG2 = cuboid(0.6875, 0, 0.1875, 0.8125, 0.5, 0.3125);
            final VoxelShape LEG3 = cuboid(0.1875, 0, 0.6875, 0.3125, 0.5, 0.8125);
            final VoxelShape LEG4 = cuboid(0.6875, 0, 0.6875, 0.8125, 0.5, 0.8125);
            //把上面四个椅子腿结合为LEGS，就可以在下面碰撞箱结合时改为LEGS缩短代码长度
            final VoxelShape LEGS = union(LEG1, LEG2, LEG3, LEG4);

            final VoxelShape BOTTOM = cuboid(0.125, 0.5, 0.125, 0.875, 0.625, 0.875);

            //四个方向的椅子背
            final VoxelShape SIDE_NORTH = cuboid(0.125, 0.625, 0.125, 0.875, 1.3125, 0.25);
            final VoxelShape SIDE_SOUTH = cuboid(0.125, 0.625, 0.75, 0.875, 1.3125, 0.875);
            final VoxelShape SIDE_EAST = cuboid(0.75, 0.625, 0.125, 0.875, 1.3125, 0.875);
            final VoxelShape SIDE_WEST = cuboid(0.125, 0.625, 0.125, 0.25, 1.3125, 0.875);
        switch(dir) {
            default:
                return VoxelShapes.union(LEGS, BOTTOM, SIDE_NORTH);
            case SOUTH:
                return VoxelShapes.union(LEGS, BOTTOM, SIDE_SOUTH);
            case EAST:
                return VoxelShapes.union(LEGS, BOTTOM, SIDE_EAST);
            case WEST:
                return VoxelShapes.union(LEGS, BOTTOM, SIDE_WEST);
        }
    }

    public BlockState getPlacementState(ItemPlacementContext ctx) {
        return (BlockState)this.getDefaultState().with(FACING, ctx.getPlayerFacing());
    }

}